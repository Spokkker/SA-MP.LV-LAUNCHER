using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MysticLauncher;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        ApplyStyling();
    }

    private void ApplyStyling()
    {
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        foreach (Control control in navPanel.Controls)
        {
            control.Margin = new Padding(0, 8, 0, 0);
        }

        playButton.Region = new Region(new Rectangle(0, 0, playButton.Width, playButton.Height));
        discordButton.Region = new Region(new Rectangle(0, 0, discordButton.Width, discordButton.Height));
        serverActionButton.Region = new Region(new Rectangle(0, 0, serverActionButton.Width, serverActionButton.Height));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Rectangle gradientArea = new Rectangle(navPanel.Width, 0, Width - navPanel.Width, Height);
        using LinearGradientBrush brush = new LinearGradientBrush(
            gradientArea,
            Color.FromArgb(24, 26, 36),
            Color.FromArgb(12, 13, 18),
            LinearGradientMode.Vertical);
        e.Graphics.FillRectangle(brush, gradientArea);
    }

    private void OnButtonClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        MessageBox.Show(
            this,
            $"\"{button.Text}\" darbība vēl nav pievienota. Šobrīd veidojam tikai vizuālo prototipu.",
            "Drīzumā",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}
