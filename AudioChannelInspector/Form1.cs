using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace AudioChannelInspector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Audio Files|*.flac;*.wav;*.aac;*.ac3;*.mp3;*.ogg;*.m4a"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
                AnalyzeAudioFile(openFileDialog.FileName);
            }
        }

        private string GetChannelOrderFromMask(int channelMask, int channels)
        {
            var channelNames = new List<string>();

            // Standard channel positions based on the bitfield
            if ((channelMask & 0x1) != 0) channelNames.Add("Front Left");
            if ((channelMask & 0x2) != 0) channelNames.Add("Front Right");
            if ((channelMask & 0x4) != 0) channelNames.Add("Center");
            if ((channelMask & 0x8) != 0) channelNames.Add("LFE (Subwoofer)");
            if ((channelMask & 0x10) != 0) channelNames.Add("Rear Left");
            if ((channelMask & 0x20) != 0) channelNames.Add("Rear Right");
            if ((channelMask & 0x40) != 0) channelNames.Add("Front Left of Center");
            if ((channelMask & 0x80) != 0) channelNames.Add("Front Right of Center");
            if ((channelMask & 0x100) != 0) channelNames.Add("Rear Center");

            // Add more mappings as needed

            return channelNames.Count > 0
                ? string.Join(", ", channelNames)
                : $"Unmapped channel mask: 0x{channelMask:X} ({channels} channels)";
        }

        private string GetWavChannelOrder(string filePath, int channels)
        {
            try
            {
                using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var binaryReader = new BinaryReader(reader))
                {
                    reader.Seek(20, SeekOrigin.Begin);
                    short audioFormat = binaryReader.ReadInt16();

                    if (audioFormat == 0xFFFE) // WAVE_FORMAT_EXTENSIBLE
                    {
                        reader.Seek(22, SeekOrigin.Begin);
                        short numChannels = binaryReader.ReadInt16();
                        if (numChannels != channels)
                        {
                            return "Mismatch in channel count.";
                        }

                        reader.Seek(46, SeekOrigin.Begin); // Offset to Channel Mask
                        int channelMask = binaryReader.ReadInt32();

                        return GetChannelOrderFromMask(channelMask, channels);
                    }
                    else if (audioFormat == 0x0001) // WAVE_FORMAT_PCM
                    {
                        // Use fallback if WAVE_FORMAT_PCM, no channel mask present
                        return GetFallbackChannelOrder(channels);
                    }
                    else
                    {
                        return "Unsupported WAV format.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error reading WAV headers: {ex.Message}";
            }
        }

        private string GetFallbackChannelOrder(int channels)
        {
            var standardChannelNames = new[]
            {
        "Front Left", "Front Right", "Center", "LFE (Subwoofer)",
        "Rear Left", "Rear Right", "Front Left of Center", "Front Right of Center",
        "Rear Center"
    };

            if (channels <= standardChannelNames.Length)
            {
                return string.Join(", ", standardChannelNames.Take(channels));
            }

            return $"{channels} channels (custom order)";
        }

        private List<string> GetAC3ChannelLayout(string filePath)
        {
            // Simulating channel layout for demonstration
            return new List<string> { "Front Left", "Front Right", "Center", "LFE", "Rear Left", "Rear Right" };
        }

        private int GetFLACChannels(string filePath, out string channelOrder)
        {
            // Simulating FLAC channel parsing
            channelOrder = "Front Left, Front Right, Rear Left, Rear Right";
            return 4;
        }

        private int GetM4AChannels(string filePath, out string channelOrder)
        {
            // Simulating M4A channel parsing
            channelOrder = "Front Left, Front Right, Center, LFE";
            return 4;
        }

        private void AnalyzeAudioFile(string filePath)
        {
            try
            {
                string channelOrder;
                int channels;

                if (filePath.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
                {
                    using (var waveFileReader = new WaveFileReader(filePath))
                    {
                        channels = waveFileReader.WaveFormat.Channels;
                        channelOrder = GetWavChannelOrder(filePath, channels);
                    }
                }
                else if (filePath.EndsWith(".ac3", StringComparison.OrdinalIgnoreCase))
                {
                    var ac3Channels = GetAC3ChannelLayout(filePath);
                    channels = ac3Channels.Count;
                    channelOrder = string.Join(", ", ac3Channels);
                }
                else if (filePath.EndsWith(".flac", StringComparison.OrdinalIgnoreCase))
                {
                    channels = GetFLACChannels(filePath, out channelOrder);
                }
                else if (filePath.EndsWith(".m4a", StringComparison.OrdinalIgnoreCase))
                {
                    channels = GetM4AChannels(filePath, out channelOrder);
                }
                else
                {
                    throw new NotSupportedException("Unsupported file format.");
                }

                txtChannels.Text = $"Channels: {channels}";
                txtChannelOrder.Text = $"Order: {channelOrder}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error analyzing file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
