Friend Class CustomPanel
    Inherits Panel

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim WheelMoveHandler As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
        WheelMoveHandler.Handled = True
    End Sub
End Class
