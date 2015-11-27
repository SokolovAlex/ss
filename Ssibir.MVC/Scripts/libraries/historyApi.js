window.historyApi = {
	getStateFromUrl: function (url) {
		var parts = url.split('/');

		if (parts.length < 2) {
			return {};
		}

		if (parts[parts.length - 2] == 'Page') {
			var newstate = {
				pagekey: parts[parts.length - 1]
			};
			if (window.history && window.history.replaceState) {
				window.history.replaceState(newstate, null);
			}
			return newstate;
		}
	},
	state: null
}