@ModelType Models.DLL.Produit
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details du produit</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
