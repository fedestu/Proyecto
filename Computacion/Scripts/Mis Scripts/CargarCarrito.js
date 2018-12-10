
function DetallesVentas() {
    $.ajax({
        url: "/VentaMaster/VentaDetalle",
        type: "post",
        success: function (retorno) {
            $("#DetalleVentas").html(retorno);
            window.location.href = '/VentaMaster/Ventas';
        },
        error: function (retorno) {
            alert("Ocurrio un error al traer las vetnas detalles");
        }
    });
};


function AgregarDetalle() {

    var idArticulo = $("#Id").val();
    var cantidad = $("#Cantidad").val();
    //alert("Cantidad= " + cantidad.toString() + " - Id = " + idArticulo.toString);
    //var verificaStock = VerificarStock(idArticulo, cantidad);

    //if (!verificaStock) {
    //    return;
    //}

    $.ajax({
        url: "/VentaMaster/AgregarArticulo",
        data: { 'IdArticulo': idArticulo, 'cantidad': cantidad },
        type: "post",
        cache: false,
        success: function () {
            DetallesVentas();            
        },
        error: function () {
            alert("Ocurrio un Error Agregando el Articulo");
        }
    });
}


function VerificarStock(idArticulo, cantidad) {

    return new Promise(resolve => {
        var retorno = false;

        $.ajax({
            url: "/VentasMaster/VerificarStock",
            data: { 'IdArticulo': idArticulo, 'cantidad': cantidad },
            type: "post",
            cache: false,
            async: false,
            success: function (retorno) {

                if (retorno == null) {
                    alert("El Articulo No existe");
                    retorno = false;

                } else {

                    if (retorno.Stock < cantidad) {

                        alert("El Stock del articulo es de " + retorno.Stock + ", la venta Sobrepasa el stock en " + (parseInt(cantidad) - retorno.Stock));
                        retorno = false;
                    }
                    else {
                        retorno = true;
                    }
                }
                return retorno;
            },
            error: function () {
                alert("Ocurrio un Error Agregando el Articulo");
            }
        });

    });
}