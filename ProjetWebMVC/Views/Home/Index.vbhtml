@ModelType Models.DLL.Utilisateur

@Code
    ViewData("Title") = "Home Page"
End Code


<h4>Données transmises par le controller</h4>
<br />

<p>Contenu ViewData : @ViewData("cle")</p>
<br />
<p>Contenu Session : @Session("cle")</p>
<br />
<h5>Utilisateur (model) transmis par le controller</h5><br/>
<p>Email : @Model.Email - Nom: @Model.Nom - Password: @Model.Password - Profil: @Model.Profil     </p>

<h5>RAZOR : moteur de vue, qui possède sa propre syntaxe</h5>
<br/>
@code
    Dim x As Integer = 10
    Dim chaine As String() = {"test", "test1", "test2"}
End Code

<p>x= @x</p><br/>

@For Each item In chaine
    @<p>@item</p>
Next
<h5>Formulaires:</h5><br/>
<p>HTML helpers de Razor:</p><br/>

<a href="#">cliquez ici</a><br/>

@Html.ActionLink("Cliquez ici", "#")

<br/>

<form method="post" action="/Conrollers/action">
    <input type="text" name="nom"/><br/>
    <input type="submit" value="Envoyer"/>

</form>
<br/><br/>
@* si aucun param dans begin form, l'action appelée est l'action qui a affiché cette vue en post*@
@Using (Html.BeginForm("action", "controller", FormMethod.Post))
    @Html.Label("Nom:")
    @Html.Editor("name")

    @*Pas de html helper pour le button submit*@
    @<input type="submit" value="Envoyer"/>

End Using

