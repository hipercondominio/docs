
/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Text = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @returns {never}
	 * */
	install: () => {

	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @argument selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {never}
	 * */
	transform: (selector) => {
		var parent = Core.Components;
		$("cks-text", selector).each(function () {
			var cks = this;
			var $cks = $(cks);
			if (cks.ready)  //já foi transformado
				return;

			///transformação
			$cks.wrapInner(`<input type="text" class="form-control" />`);

			var $target = $("INPUT", cks);
			var target = $target[0];

			///propriedades
			var _align;
			var _chars;
			var _helpDisabled;
			var _mask;
			var _tabindex;
			Object.defineProperties(cks, {
				"align": {
					get: () => {
						return _align;
					},
					set: (v) => {
						_align = v;
						$target.css("text-align", v);
					},
				},
				"autocomplete": {
					get: () => {
						return target.autocomplete;
					},
					set: (v) => {
						target.autocomplete = v;
					},
				},
				"chars": {
					get: () => {
						return _chars;
					},
					set: (v) => {
						_chars = v;
					},
				},
				"disabled": {
					get: () => {
						return target.disabled;
					},
					set: (v) => {
						target.disabled = v;
					},
				},
				"helpDisabled": {
					get: () => {
						return _helpDisabled;
					},
					set: (v) => {
						_helpDisabled = v;
						if (cks.disabled) {
							cks.title = v;
						}
					},
				},
				"list": {
					get: () => {
						return target.list;
					},
					set: (v) => {
						target.list = v;
					},
				},
				"mask": {
					get: () => {
						return _mask;
					},
					set: (v) => {
						_mask = v;
						Inputmask(cks.mask).mask(target);
					},
				},
				"maxlength": {
					get: () => {
						return target.maxlength;
					},
					set: (v) => {
						target.maxlength = v;
					},
				},
				"name": {
					get: () => {
						return target.name;
					},
					set: (v) => {
						target.name = v;
					},
				},
				"pattern": {
					get: () => {
						return target.pattern;
					},
					set: (v) => {
						target.pattern = v;
					},
				},
				"placeholder": {
					get: () => {
						return target.placeholder;
					},
					set: (v) => {
						target.placeholder = v;
					},
				},
				"readonly": {
					get: () => {
						return target.readOnly;
					},
					set: (v) => {
						target.readOnly = v;
					},
				},
				"required": {
					get: () => {
						return target.required;
					},
					set: (v) => {
						target.required = v;
					},
				},
				"tabIndex": {
					get: () => {
						return $target.attr("tabindex");
					},
					set: (v) => {
						$target.attr("tabindex", v);
					},
				},
				"value": {
					get: () => {
						return target.value;
					},
					set: (v) => {
						target.value = v;
					},
				},
			});

			///extrair atributos e setar propriedades
			parent.attr(cks, "align", "string");
			parent.attr(cks, "autocomplete", "string");
			parent.attr(cks, "chars", "string");
			parent.attr(cks, "disabled", "boolean");
			parent.attr(cks, "help-disabled", "string");
			parent.attr(cks, "hidden", "boolean");
			parent.attr(cks, "list", "string");
			parent.attr(cks, "mask", "string");
			parent.attr(cks, "maxlength", "string");
			parent.attr(cks, "name", "string");
			parent.attr(cks, "pattern", "string");
			parent.attr(cks, "placeholder", "string");
			parent.attr(cks, "readonly", "boolean");
			parent.attr(cks, "required", "string");
			parent.attr(cks, "tab-index", "number");
			parent.attr(cks, "value", "string");

			///métodos
			cks.focus = () => {
				$target.focus();
			}
			cks.blur = () => {
				$target.blur();
			}

			///eventos
			parent.event(target, "focus", cks);
			parent.event(target, "blur", cks);

			//eventos internos
			$cks.on("keypress", function (e) {
				var k = String.fromCharCode(e.which);
				var charList = e.target.parentNode.chars;
				var reValid = new RegExp(`[${charList}]`);
				if (!reValid.test(k)) {
					return false;
				}
			});

			this.ready = true;
		});
	},
}
