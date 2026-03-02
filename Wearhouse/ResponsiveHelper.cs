using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Wearhouse
{
    public class ResponsiveHelper
    {
        private Form form;
        private Dictionary<string, Rectangle> originalBounds = new Dictionary<string, Rectangle>();
        private Dictionary<string, Font> originalFonts = new Dictionary<string, Font>();
        private Size originalFormSize;
        private FormWindowState lastWindowState;

        public ResponsiveHelper(Form targetForm)
        {
            form = targetForm;
            originalFormSize = form.ClientSize;
            lastWindowState = form.WindowState;
            StoreOriginalBounds();
            StoreOriginalFonts();
        }

        private void StoreOriginalBounds()
        {
            foreach (Control control in GetAllControls(form))
            {
                originalBounds[control.Name] = control.Bounds;
            }
        }

        private void StoreOriginalFonts()
        {
            foreach (Control control in GetAllControls(form))
            {
                try
                {
                    originalFonts[control.Name] = new Font(control.Font.FontFamily, control.Font.Size, control.Font.Style);
                }
                catch
                {
                    // Ignore font storage errors
                }
            }
        }

        private List<Control> GetAllControls(Control parent)
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in parent.Controls)
            {
                if (!string.IsNullOrEmpty(control.Name))
                {
                    controls.Add(control);
                }
                // Recursively add child controls
                controls.AddRange(GetAllControls(control));
            }
            return controls;
        }

        public void ResizeControls()
        {
            if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
                return;

            float scaleX = (float)form.ClientSize.Width / originalFormSize.Width;
            float scaleY = (float)form.ClientSize.Height / originalFormSize.Height;

            foreach (Control control in GetAllControls(form))
            {
                if (originalBounds.ContainsKey(control.Name))
                {
                    Rectangle originalBound = originalBounds[control.Name];

                    // Scale position
                    int newX = (int)(originalBound.X * scaleX);
                    int newY = (int)(originalBound.Y * scaleY);

                    // Scale size
                    int newWidth = (int)(originalBound.Width * scaleX);
                    int newHeight = (int)(originalBound.Height * scaleY);

                    control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);

                    // Scale font
                    ScaleFont(control, scaleX, scaleY);
                }
            }
        }

        private void ScaleFont(Control control, float scaleX, float scaleY)
        {
            try
            {
                if (originalFonts.ContainsKey(control.Name))
                {
                    Font originalFont = originalFonts[control.Name];
                    float newFontSize = originalFont.Size * Math.Min(scaleX, scaleY);
                    newFontSize = Math.Max(newFontSize, 8); // Minimum font size
                    control.Font = new Font(originalFont.FontFamily, newFontSize, originalFont.Style);
                }
            }
            catch
            {
                // Ignore font scaling errors
            }
        }

        public void ResetToOriginal()
        {
            foreach (Control control in GetAllControls(form))
            {
                if (originalBounds.ContainsKey(control.Name))
                {
                    control.Bounds = originalBounds[control.Name];
                }

                if (originalFonts.ContainsKey(control.Name))
                {
                    try
                    {
                        Font originalFont = originalFonts[control.Name];
                        control.Font = new Font(originalFont.FontFamily, originalFont.Size, originalFont.Style);
                    }
                    catch
                    {
                        // Ignore font reset errors
                    }
                }
            }
        }

        public void HandleWindowStateChange()
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                ResizeControls();
            }
            else if (form.WindowState == FormWindowState.Normal)
            {
                ResetToOriginal();
            }
            lastWindowState = form.WindowState;
        }

        public static void EnableResponsive(Form form)
        {
            ResponsiveHelper helper = new ResponsiveHelper(form);
            form.Resize += (s, e) => 
            {
                // Check if window state changed (maximized/restored)
                if (helper.lastWindowState != form.WindowState)
                {
                    helper.HandleWindowStateChange();
                }
                else
                {
                    helper.ResizeControls();
                }
            };
        }
    }
}
