"use strict";
var PuestosGrid;
(function (PuestosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Puestos/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    PuestosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(PuestosGrid || (PuestosGrid = {}));
//# sourceMappingURL=Grid.js.map