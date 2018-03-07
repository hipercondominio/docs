var hasAccordion = true;
while (hasAccordion) {
	var hasAccordion = false;
	$("accordion").each(function () {
		if (this.dataset.ok)
			return;
		hasAccordion = true;

		//atributos componente
		var order = $(this).attr("order") || "";
		order = order.toLowerCase();

		var collapses = $("> collapse", this);
		var items = [];
		if (order == "name") {
			$(collapses).each(function () {
				let item = { name: $(this).attr("name"), contents: $(this) };
				items.push(item);
			});
			items.sort((a, b) => {
				return a.name > b.name ? 1 : -1;
			});
			for (let item of items) {
				$(this).append(item.contents);
			}
		}

		this.dataset.ok = true;
	});
}

var hasCollapse = true;
while (hasCollapse) {
	var hasCollapse = false;
	$("accordion collapse").each(function () {
		if (this.dataset.ok)
			return;
		hasCollapse = true;

		//atributos componente
		var name = $(this).attr("name");
		var contents = $(this).html();

		//transferência do conteúdo
		$(this).html("<span class='temp'></span>");
		
		//transformação
		$(this).wrapInner(`
			<div class="card">
				<div class="card-header" id="Card${name}">
					<h5 class="mb-0">
						<button class="btn btn-link collapsed" data-toggle="collapse" data-target="#${name}" aria-expanded="false" aria-controls="collapseOne">
							${name}
						</button>
					</h5>
				</div>

				<div id="${name}" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">
					<div class="card-body">
						${contents}
					</div>
				</div>
			</div>
		`);
		$(".temp", this).contents().unwrap();
		window.setTimeout(function () {
			//somente ocultar após processamento js dos controles internos, e estiver ocioso
			$(".collapse.show").removeClass("show");
		});

		this.dataset.ok = true;
	});
}

var hasKv = true;
while (hasKv) {
	var hasKv = false;
	$("kv").each(function () {
		if (this.dataset.ok)
			return;
		hasKv = true;

		//atributos componente
		var name = $(this).attr("name");
		var _default = $(this).attr("default");
		var type = $(this).attr("type") || "";
		var mode = $(this).attr("mode") || "";
		mode = mode.toLowerCase();

		var classes = ($(this).attr("class") || "").split(" ");
		if (_default == "")   //se padrão, criar destaque
			classes.push("code-data-default");

		//atributos html
		var attrs = [];
		var _class = classes.join(' ');
		if (_class != "")
			attrs.push(`class="${_class}"`);
		attrs = attrs.join(" ");

		//transformação
		if (mode == "block") {
			$(this).wrapInner(`<div class="indent-1">`);
		}
		var contents = $(this).html();
		$(this).html("");
		var result = `<div><b ${attrs}>${name}</b> <i>${type}</i>: ${contents}</div>`;
		result = result.replace(" <i></i>", "");
		$(this).wrapInner(result);

		this.dataset.ok = true;
	});
}

$("comp").each(function () {
	//atributos componente
	var name = $(this).attr("name");


	//transformação
	$(this).wrapInner(`<a href="#${name}">${name}</a>`);
	$(this).contents().unwrap();    //remoção tag
});

$("spacer").each(function () {
	//atributos componente
	var len = $(this).attr("len");
	$(this).css("display", "inline-block");
	$(this).css("height", `${len}px`);
});

$(".code-data-default").each(function () {
	$(this).attr("title", "Padrão");
});

//hack: fazer esfuminho durante a transformação
