$(function () {
    $("#TextArticulo").keyup(function () {

        var txt = $(this).val();

        if (txt == null || txt == "") {

            $("#DivDinamicoArticulo").html("");
            $("#TextPrecioCompraViejo").val("");
            $("#TextPrecioVentaViejo").val("");
            $("#IdArticulo").val("");
        } else {
            BuscarArticuloCompra(txt);
            //SelectedTr();
        }
    });

    $("#IdArticulo").change(

        function () {

            var idArticulo = $(this).val();

            if (idArticulo == null || idArticulo == 0) {
                $("#TextArticulo").val("");
                $("#TextPrecioCompraViejo").val("");
                $("#TextPrecioVentaViejo").val("");
                $("#IdArticulo").val("");
                return;
            } else {
                BuscarArticuloPorId(idArticulo);
            }

        }
    )
});

function BuscarArticuloCompra(textoABuscar) {


    if (textoABuscar == null || textoABuscar == "") {

        $("#DivDinamicoArticulo").html("");
        return;
    }

    //Creamos una funcion ajax que envie los datos al metodo Buscar del Controler Persona
    $.ajax({
        //Direccion donde nos queremos comunicar Controller/Metodo
        url: "/Articulo/BuscarArticulos",
        //parametros que le pasamos a el Metodo del Controller ( si se fijan en el Controller el metodo Busqueda, recibe como parametro "filtro")
        data: { "articulo": textoABuscar },
        //El tipo es post ya que enviamos datos
        type: "post",
        cache: false,
        success: function (retorno) {
            //Si el metodo busqueda del controller devuelve algo, lo guardamos en retorno - lo que devuelve es la pagina (View) buscar, osea es un pedazo de codigo HTML que podemos insertar en el DivDinamico
            if (retorno == null || retorno == "") {

                $("#DivDinamicoArticulo").html("<p class='SinResultados'>No Se encontraron resutado</p>");
                return;

            }
            $("#DivDinamicoArticulo").html(retorno);

        },
        error: function (retorno) {
            //Si el metodo ajax falla entra por aca y nos advierte de un error

            alert("Se ha producido un error");


        }
    });


}

function BuscarArticuloPorId(idArticulo) {
    var IdArticulo = idArticulo;    
    $.ajax({

        url: "/Articulo/BuscarArticuloPorId",
        data: { "id": IdArticulo },
        type: "post",
        cache: false,
        success: function (ArticuloRetorno) {
            $("#TextArticulo").val(ArticuloRetorno.Descripcion);
            $("#IdArticulo").val(ArticuloRetorno.Id);
            $("#TextPrecioCompraViejo").val(ArticuloRetorno.PrecioCompra);
            $("#TextPrecioVentaViejo").val(ArticuloRetorno.PrecioVenta);
            $("#DivDinamicoArticulo").html("");
            $("#PrecioCompra").focus();
        },
        error: function (ArticuloRetorno) {

            alert("Se ha producido un error");

        }

    });


}
