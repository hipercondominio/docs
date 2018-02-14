//todo: fazer esfuminho.

$("accordion").each(function () {
	$(this).wrapInner("<div>");
	//atributos temporários
	var order = $(this).attr("order");
	order = order.toLowerCase();

	var collapses = $("collapse", this);
	var items = [];
	if (order == "title") {
		$(collapses).each(function () {
			let item = { title: $(this).attr("title"), contents: $(this) };
			items.push(item);
		});
		items.sort((a, b) => {
			return a.title > b.title ? 1 : -1;
		});
		$(this).empty();
		for (let item of items) {
			$(this).append(item.contents);
		}
	}

});

$("accordion collapse").each(function() {
	//atributos temporários
	var title = $(this).attr("title");
	var contents = $(this).html();

	//transferência do conteúdo
	$(this).html("");

	//transformação
	$(this).wrapInner(`
		<div class="card">
			<div class="card-header" id="headingOne">
				<h5 class="mb-0">
					<button class="btn btn-link collapsed" data-toggle="collapse" data-target="#${title}" aria-expanded="false" aria-controls="collapseOne">
						${title}
					</button>
				</h5>
			</div>

			<div id="${title}" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
				<div class="card-body">
					${contents}
				</div>
			</div>
		</div>
	`);
	$(this).contents().unwrap();    //remoção tag
});
while ($("kv").length != 0) {              
	$("kv").each(function() {
		//atributos temporários
		var title = $(this).attr("title");
		var _default = $(this).attr("default");
		var type = $(this).attr("type") || "";
		var mode = $(this).attr("mode") || "";
		mode = mode.toLowerCase();

		var classes = ($(this).attr("class") || "").split(" ");
		if (_default == "")   //se padrão, criar destaque
			classes.push("code-data-default");

		//atributos permanentes
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
		var result = `<div><b ${attrs}>${title}</b> <i>${type}</i>: ${contents}</div>`;
		result = result.replace(" <i></i>", "");
		$(this).wrapInner(result);

		$(this).contents().unwrap();    //remoção tag
	});
}
$("comp").each(function() {
	//atributos temporários
	var name = $(this).attr("name");


	//transformação
	$(this).wrapInner(`<a href="#${name}">${name}</a>`);
	$(this).contents().unwrap();    //remoção tag
});
$("spacer").each(function () {
	//atributos temporários
	var len = $(this).attr("len");

	$(this).wrapInner(`<div style='height: ${len}px'>`);
});



$(".code-data-default").each(function() {
	$(this).attr("title", "Padrão");
});