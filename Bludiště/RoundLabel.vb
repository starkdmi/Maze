Imports System.Drawing.Drawing2D
Public Class RoundLabel
    Inherits Label
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim DrawingPath As GraphicsPath = New GraphicsPath()
        DrawingPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)
        Me.Region = New Region(DrawingPath)
        MyBase.OnPaint(e)
    End Sub
End Class
