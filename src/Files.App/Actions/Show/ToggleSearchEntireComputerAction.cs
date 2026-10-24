// Copyright (c) Files Community
// SPDX-License-Identifier: MPL-2.0

namespace Files.App.Actions
{
	[GeneratedRichCommand]
	internal sealed partial class ToggleSearchEntireComputerAction : ObservableObject, IToggleAction
	{
		private readonly IGeneralSettingsService GeneralSettingsService;

		public string Label
			=> Strings.SearchEntireComputer.GetLocalizedResource();

		public string Description
			=> Strings.ToggleSearchEntireComputerDescription.GetLocalizedResource();

		public RichGlyph Glyph
			=> new("");

		public ActionCategory Category
			=> ActionCategory.Show;

		public bool IsOn
			=> GeneralSettingsService.SearchEntireComputerWithEverything;

		public ToggleSearchEntireComputerAction()
		{
			GeneralSettingsService = Ioc.Default.GetRequiredService<IGeneralSettingsService>();

			GeneralSettingsService.PropertyChanged += Settings_PropertyChanged;
		}

		public Task ExecuteAsync(object? parameter = null)
		{
			GeneralSettingsService.SearchEntireComputerWithEverything = !GeneralSettingsService.SearchEntireComputerWithEverything;

			return Task.CompletedTask;
		}

		private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName is nameof(IGeneralSettingsService.SearchEntireComputerWithEverything))
				OnPropertyChanged(nameof(IsOn));
		}
	}
}
