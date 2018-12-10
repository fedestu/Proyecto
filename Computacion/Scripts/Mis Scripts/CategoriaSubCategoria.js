$(function () {

    actualizarSubCategorias();

});

function actualizar() {

    var idCategoria = $("#IdCategoria").val();

    $.ajax({

        url: "/Arituculo/GetSubcategoria",
        data: { "idCategoria": idCategoria },
        type: "post",
        cache: false,
        success: function (retorno) {

            $("#IdSubCategoria").html("");
            $("#ComboSubCategoria").html(retorno);

        },
        error: function (retorno) {
            alert("Se ha producido un error al cargar el combo.");
        }

    });

}

function actualizarSubCategorias() {
    var idCategoria = $("#IdCategoria").val();

    $.ajax({
        //Direccion donde nos queremos comunicar Controller/Metodo
        url: "/Articulo/GetSubCategoria",
        //parametros que le pasamos a el Metodo del Controller ( si se fijan en el Controller el metodo Busqueda, recibe como parametro "idProvincia")
        data: { 'idCategoria': idCategoria },
        //El tipo es post ya que enviamos datos
        type: "post",
        cache: false,
        success: function (retorno) {
            //Si el metodo busqueda del controller devuelve algo, lo guardamos en retorno - lo que devuelve una lista de personas, osea es un pedazo de codigo HTML que podemos insertar en el Combo de localidades
            $("#IdSubCategoria").html(''); //Primero limpiamos el combo localidades
            $("#ComboSubCategoria").html(retorno);

            ////Recorremos el listado y vamos armando el Html del Combo
            //$.each(retorno,
            //    function (index, type) {
            //        var content = '<option value="' + type.Id + '">' + type.Descripcion + '</option>';
            //        $("#IdSubCategoria").append(content); //vamos agregando cada linea de codigo para generar el combo
            //    });

        },
        error: function (retorno) {
            //Si el metodo ajax falla entra por aca y nos advierte de un error

            alert("Se ha producido un error en la carga del combo");


        }
    });



}
