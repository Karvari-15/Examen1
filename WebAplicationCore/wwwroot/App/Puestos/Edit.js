"use strict";
var PuestosEdit;
(function (PuestosEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(PuestosEdit || (PuestosEdit = {}));
//# sourceMappingURL=Edit.js.map