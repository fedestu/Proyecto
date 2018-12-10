function QuitarArticulo(idArticulo) {

    //var idArticulo = $("#IdArticulo").val();    
    
    $.ajax({
        url: "/VentaMaster/QuitarArticulo",
        data: { 'IdArticulo': idArticulo},
        type: "post",
        cache: false,
        success: function () {
            DetallesVentas();
        },
        error: function () {
            alert("Ocurrio un Error quitando el Articulo.");
        }
    });
}

function ModificarCantidad(idArticulo) {

    //var idArticulo = $("#IdArticulo").val();
    var cantidad = $("#"+idArticulo).val();    

    $.ajax({
        url: "/VentaMaster/ModificarCantidad",
        data: { 'IdArticulo': idArticulo , 'cantidad' : cantidad},
        type: "post",
        cache: false,
        success: function () {
            DetallesVentas();
        },
        error: function () {
            alert("Ocurrio un Error modificando la cantidad.");
        }
    });
}