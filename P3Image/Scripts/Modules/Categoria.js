$(function(){

    var GenericObject = function (id, descricao) {
        this.Id = id;
        this.Descricao = descricao;
    };

    var SubCategoriaModel = function (id, descricao, categoriaId, campos) {
        this.Id = ko.observable(id);
        this.Descricao = ko.observable(descricao);
        this.CategoriaId = ko.observable(categoriaId);
        this.Campos = ko.observableArray(campos);
    }

    var Campo = function (id, descricao, subCategoriaId, tipoId, valores) {
        this.Id = ko.observable(id);
        this.Descricao = ko.observable(descricao);
        this.TipoId = ko.observable(tipoId);
        this.SubCategoriaId = ko.observable(subCategoriaId);
        this.Valores = ko.observableArray(valores);
    };

    var CampoValor = function (id, campoId, tipoId, valor) {
        this.Id = id;
        this.CampoId = campoId;
        this.TipoId = tipoId;
        this.Valor = valor;
    };

    var CategoriaModel = function () {
        var self = this;
        self.CategoriaSelected = ko.observable();
        self.NovaCategoria = ko.observable();
        self.NovoCampo = ko.observable();
        self.TipoCampo = ko.observable();
        self.ListValues = ko.observableArray();

        self.Categorias = ko.observableArray(_categoriaModel.Categorias);
        self.SubCategorias = ko.mapping.fromJS(_categoriaModel.SubCategorias);
        
        self.novaCategoria = function (model, e) {
            $.getJSON("/Categoria/AddCategoria", { nomeCategoria: model.NovaCategoria() }, function (id) {
                model.Categorias.push(new GenericObject(id, model.NovaCategoria()));
            });
            $('#popUpNovaCategoria').hide();
            return false;
        }

        self.novaSubCategoria = function (model, e) {
            $.getJSON("/Categoria/AddSubCategoria", { idCategoria: model.CategoriaSelected() }, function (id) {
                model.SubCategorias.push(new SubCategoriaModel(id, "", model.CategoriaSelected(), []));
            });
            return true;
        }

        self.novoCampo = function (model, e) {
            var tipoCampo = parseInt($(e.currentTarget).prev().prev().prev().children().last().val());
            var subCategoriaId =  parseInt($(e.currentTarget).prev().prev().prev().prev().val());
            var descricao = $(e.currentTarget).prev().children().last().val();
            var listValues = [];

            $.getJSON("/Categoria/AddCampo", { descricao: descricao, subCategoriaId: subCategoriaId, tipoId: tipoCampo }, function (idCampo) {
                var campoId = idCampo;
                if (tipoCampo > 2) {
                    $(e.currentTarget).prev().prev().children().last().children().children().children().each(function (index) {
                        var size = $(e.currentTarget).prev().prev().children().last().children().children().children().length;
                        var value = $(this).text();
                        $.getJSON("/Categoria/AddCampoValor", { campoId: campoId, valor: value }, function (id) {
                            listValues.push(new CampoValor(id, campoId, 3, value));
                            if (listValues.length == size -1)
                                model.Campos.push(ko.mapping.fromJS(new Campo(campoId, descricao, subCategoriaId, tipoCampo, listValues)));
                        });
                    });
                }
                else
                    model.Campos.push(ko.mapping.fromJS(new Campo(campoId, descricao, subCategoriaId, tipoCampo, [])));
            });
            $(e.currentTarget).parent().parent().parent().parent().parent().parent().parent().parent().hide();
        }

        self.changeTipoCampo = function (model, e) {
            var tipoCampo = $(e.currentTarget).val();

            if (tipoCampo > 2) {
                $(e.currentTarget).parent().next().show();
                $(e.currentTarget).parent().next().next().hide();
            }
            else {
                $(e.currentTarget).parent().next().hide();
                $(e.currentTarget).parent().next().next().show();
            }
        }

        self.changeCategoria = function (model, e) {
            $.getJSON("/Categoria/GetSubCategoriasByIdCategoria", { idCategoria: model.CategoriaSelected() }, function (subCategorias) {
                debugger;
                self.SubCategorias(ko.mapping.fromJS(subCategorias));
            });
        }

        self.updateNomeSubCategoria = function (model, e) {
            debugger;
            $.getJSON("/Categoria/UpdateNomeSubCategoria", { idSubCategoria: model.Id(), descricao: model.Descricao() }, function () {
                debugger;
            });
        }

        self.openPopUp = function (model, e) {
            $(e.currentTarget).parent().parent().parent().next().show();

            var addPill = function ($input) {
                var $text = $input.val(), $pills = $input.closest('.pillbox'), $repeat = false, $repeatPill;
                if ($text == "") return;
                $("li", $pills).text(function (i, v) {
                    if (v == $text) {
                        $repeatPill = $(this);
                        $repeat = true;
                    }
                });
                if ($repeat) {
                    $repeatPill.fadeOut().fadeIn();
                    return;
                };
                $item = $('<li class="label bg-dark">' + $text + '</li> ');
                $item.insertBefore($input);
                $input.val('');
                $pills.trigger('change', $item);
            };

            $('.pillbox input').on('blur', function () {
                addPill($(this));
            });

            $('.pillbox input').on('keypress', function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    addPill($(this));
                }
            });
        }
    }

    ko.applyBindings(new CategoriaModel());
});

