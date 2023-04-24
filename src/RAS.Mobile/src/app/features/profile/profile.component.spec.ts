import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed, inject } from '@angular/core/testing';
import { TranslateService } from '@ngx-translate/core';
import { TranslateTestingModule } from 'ngx-translate-testing';
import { AccountService } from '../../core/services/account.service';
import { ProfileComponent } from './profile.component';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
declare let require: any;

describe('ProfileComponent', () => {
	let component: ProfileComponent;
	let fixture: ComponentFixture<ProfileComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [ProfileComponent],
			imports: [
				HttpClientModule,
				TranslateTestingModule.withTranslations({
					// eslint-disable-next-line @typescript-eslint/no-unsafe-assignment, @typescript-eslint/no-unsafe-call
					en: require('src/assets/i18n/en.json'),
					// eslint-disable-next-line @typescript-eslint/no-unsafe-assignment, @typescript-eslint/no-unsafe-call
					lt: require('src/assets/i18n/lt.json'),
				}),
			],
			providers: [AccountService],
		}).compileComponents();

		fixture = TestBed.createComponent(ProfileComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});

	// eslint-disable-next-line @typescript-eslint/no-unsafe-argument
	it('should render english', inject([TranslateService], (translateService: TranslateService) => {
		translateService.setDefaultLang('en');
		fixture.detectChanges();
		const debugElement = fixture.debugElement;
		const compiled = debugElement.nativeElement as HTMLElement;

		expect(compiled.querySelector('#title')?.innerHTML).toContain('Profile');
	}));

	// eslint-disable-next-line @typescript-eslint/no-unsafe-argument
	it('should render lithuanian', inject([TranslateService], (translateService: TranslateService) => {
		translateService.setDefaultLang('lt');
		fixture.detectChanges();
		const debugElement = fixture.debugElement;
		const compiled = debugElement.nativeElement as HTMLElement;

		expect(compiled.querySelector('#title')?.innerHTML).toContain('Profilis');
	}));
});
