Public Class WebForm1

    Inherits System.Web.UI.Page
    Dim DictionaryURL As String = "https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt"
    Dim MaxWL As Integer = 16
    Dim MinWL As Integer = 2

    Protected Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Remember As String = MaxLengthDrop.SelectedValue
        MaxLengthDrop.Items.Clear()
        BuildNumberList(MaxLengthDrop, 64)
        MaxLengthDrop.SelectedValue = Remember
    End Sub
    Protected Sub GenButton_Click(sender As Object, e As EventArgs) Handles GenButton.Click
        GenerateButtonPressed()
    End Sub
    Protected Sub SymbolsCheckBoxAction(sender As Object, e As EventArgs) Handles SymbolsCheck.CheckedChanged
        CheckBoxAction(SymbolsCheck, SymbolsDrop)
    End Sub
    Protected Sub MaxCheckBoxAction(sender As Object, e As EventArgs) Handles MaxCheckBox.CheckedChanged
        CheckBoxAction(MaxCheckBox, MaxLengthDrop)
    End Sub
    Protected Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        CopyButtonPressed()
    End Sub
    Protected Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearButtonPressed()
    End Sub
    Protected Sub DonateButton_Click(sender As Object, e As EventArgs) Handles DonateButton.Click
        GoToWeb("pp")
    End Sub
    Protected Sub PatreonButton_Click(sender As Object, e As EventArgs) Handles PatreonButton.Click
        GoToWeb("pt")
    End Sub
    Protected Sub FacebookButton_Click(sender As Object, e As EventArgs) Handles FacebookButton.Click
        GoToWeb("fb")
    End Sub
    Protected Sub DiscordButton_Click(sender As Object, e As EventArgs) Handles DiscordButton.Click
        GoToWeb("dc")
    End Sub
    Protected Sub ContactButton_Click(sender As Object, e As EventArgs) Handles ContactButton.Click
        GoToWeb("cu")
    End Sub
    Protected Sub CheckBoxAction(check As CheckBox, drop As DropDownList)
        If check.Checked = True Then drop.Enabled = True Else drop.Enabled = False
    End Sub
    Protected Sub GenerateButtonPressed()
        GeneratedBox.Text = BuildGenerated()
        StatusLabel.ForeColor = System.Drawing.Color.DarkGreen
        StatusLabel.Text = "Strong Password Generated. :)"
    End Sub
    Protected Sub ClearButtonPressed()
        SymbolsCheck.Checked = False
        SymbolsDrop.SelectedIndex = 0
        SymbolsDrop.Enabled = False
        GeneratedBox.Text = ""
        StatusLabel.Text = ""
    End Sub
    Protected Sub CopyButtonPressed()
        If GeneratedBox.Text = "" Then
            StatusLabel.ForeColor = System.Drawing.Color.Red
            StatusLabel.Text = "The field is blank.  Generated a password first!"
        Else
            Dim t As New System.Threading.Thread(AddressOf CopyGenerated)
            t.ApartmentState = System.Threading.ApartmentState.STA
            t.Start()
            StatusLabel.ForeColor = System.Drawing.Color.Blue
            StatusLabel.Text = "Strong Password Copied To Copyboard!"
        End If
    End Sub
    Protected Sub CopyGenerated()
        System.Windows.Forms.Clipboard.SetText((GeneratedBox.Text.ToString))
    End Sub
    Protected Function BuildGenerated() As String
        Dim Stronk As String = ""
        Do While Stronk.Length < CInt(MaxLengthDrop.Text)
            Dim NewWord = GetWord()
            If NewWord <> "" Then Stronk &= NewWord & SymbolsDrop.Text.ToString
        Loop
        Stronk = Stronk.Substring(0, Stronk.Length - 1)
        Stronk &= SymbolsDrop.Text & RandomNumber()
        Return Stronk
    End Function
    Protected Function RandomWord() As String
        Dim wc As New System.Net.WebClient
        Dim r As New Random
        Dim RandomWordSelected As String() = wc.DownloadString(DictionaryURL).Split(Environment.NewLine)
        Return RandomWordSelected(r.Next(1, RandomWordSelected.Length))
    End Function
    Protected Function GetWord() As String
        Dim TempWord = RandomWord()
        If CheckWord(TempWord) = True Then
            Return UppercaseFirstLetter(TempWord)
        Else
            GetWord()
        End If
    End Function
    Protected Function RandomNumber() As String
        Return CStr(Int((999 - 100 + 1) * Rnd() + 100))
    End Function
    Protected Function CheckWord(word As String) As Boolean
        Dim Decision As Boolean
        If word.Length > MinWL Then Decision = True Else Return False
        If word.Length < MaxWL And Decision = True Then Return Decision Else Return False
    End Function
    Protected Function UppercaseFirstLetter(ByVal val As String) As String
        Dim LenTrim As Integer
        If val.Length > 1 Then LenTrim = 2 Else LenTrim = 1
        Return New String(val.Substring(0, LenTrim).ToUpper & val.Substring(LenTrim))
    End Function
    Protected Sub BuildNumberList(list As DropDownList, max As Integer)
        For x = 16 To max
            list.Items.Add(x)
        Next
    End Sub
    Protected Sub GoToWeb(type As String)
        Select Case LCase(type)
            Case "pp"
                Process.Start("https://www.paypal.me/AznBlusuazn")
            Case "pt"
                Process.Start("https://www.patreon.com/clarktribegames")
            Case "fb"
                Process.Start("https://www.facebook.com/clarktribe.games")
            Case "dc"
                Process.Start("https://discord.gg/6kW4der")
            Case "cu"
                Process.Start("mailto:info@clarktribegames.com")
        End Select
    End Sub

End Class
