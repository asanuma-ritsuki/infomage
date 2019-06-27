Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ButtonEX
    Inherits System.Windows.Forms.Button

    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        MyBase.OnPaint(e)
    End Sub
End Class
