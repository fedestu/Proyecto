﻿$(function () {
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
    
});
function BuscarArticuloCompra(textoABuscar) {


    if (textoABuscar == null || textoABuscar == "") {

        $("#DivDinamicoArticulo").html("");
        return;
    }

    //Creamos una funcion ajax que envie los datos al metodo Buscar del Controler Persona
    $.ajax({
        //Direccion donde nos queremos comunicar Controller/Metodo
        url: "/Articulo/BuscarArticulosIndex",
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