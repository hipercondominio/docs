/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.SPLITTER = {
	Descriptor: {
		tag: null,
		parent: null,
		children: [{ Panel: { ocorrences: { min: 2, max: 2 } } }],
		properties: {
			direction: ['left', 'right'],
			proportion: "array",
			orientation: ["horizontal", "vertical"],
		},
	},
	transform: function () {
		//hack: adicionar background e alguns comportamentos, como o clique no centro expandir tudo

		var splitter = $("Splitter:first")[0];
		Core.Components.importProperties(splitter);

		var position = null;
		if (splitter.proportion) {
			var panelLen = splitter.orientation == 'horizontal' ? splitter.offsetHeight : splitter.offsetWidth;

			//converter % para px
			let i = 0;
			for (let p of splitter.proportion) {
				if (p.toString().endsWith("%")) {
					var prop = parseFloat(p);
					p = panelLen * prop / 100;
					splitter.proportion[i] = p;
				}
				i++;
			}

			if (splitter.proportion[0] == "*") {    //painel 1 é o resto do 2
				position = panelLen - splitter.proportion[1];
			} else {
				position = splitter.proportion[0];
			}
		}

		$(splitter).height(splitter.offsetHeight).split({
			orientation: splitter.orientation,
			limit: 1,
			position: position, // if there is no percentage it interpret it as pixels
		});
	}
}


Core.Components.SPLITTER.transform();