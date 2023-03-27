import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AvailableCultures } from './constants/culture.constants';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
declare let require: any;

@Injectable({ providedIn: 'root' })
export class AppInitializer {
	constructor(private translateService: TranslateService, private router: Router) {
		// Nothing
	}

	public async initialize(): Promise<void> {
		try {
			AvailableCultures.forEach((x) => {
				this.translateService.setTranslation(
					`${x.isoCode}`,
					// eslint-disable-next-line @typescript-eslint/no-unsafe-argument, @typescript-eslint/no-unsafe-call
					require(`../../assets/i18n/${x.isoCode}.json`),
				);
			});
			const defaultCulture = AvailableCultures.find((x) => x.default === true);

			// eslint-disable-next-line @typescript-eslint/no-non-null-assertion
			this.translateService.setDefaultLang(defaultCulture!.isoCode);
		} catch (error) {
			this.router.navigate(['/logout']);
		} finally {
			// ignore
		}
	}
}
