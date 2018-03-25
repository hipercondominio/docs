Cks.Extensions.Number = {
	apply: () => {
		Number.parse = function (v) {
			var evaluated = eval(v);
			if (evaluated == v)
				return eval(v);
			else
				return null;
		}
	},
}

