using TagDataTranslation;

namespace TdtMauiExample;

public partial class MainPage : ContentPage
{
    private readonly TDTEngine _engine = new();

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnTranslateClicked(object? sender, EventArgs e)
    {
        var hex = HexInput.Text?.Trim();
        if (string.IsNullOrEmpty(hex))
        {
            ResultLabel.Text = "Please enter a hex value.";
            return;
        }

        try
        {
            var binary = _engine.HexToBinary(hex);

            var pureIdentity = _engine.Translate(binary, "", "PURE_IDENTITY");
            var tagUri = _engine.Translate(binary, "", "TAG_ENCODING");
            var legacy = _engine.Translate(binary, "", "LEGACY");

            ResultLabel.Text = $"Pure Identity:\n{pureIdentity}\n\n" +
                               $"Tag URI:\n{tagUri}\n\n" +
                               $"Legacy:\n{legacy}";
        }
        catch (Exception ex)
        {
            ResultLabel.Text = $"Error: {ex.Message}";
        }
    }
}
