@ModelType Models.DLL.Produit
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Supprimer le produit</h2>

<h3>Etes-vous sûr ???</h3>
<div>
    <h4>Produit</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Prix)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Prix)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Quantite)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Quantite)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-primary" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
