import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';
import { TranslateModule } from '@ngx-translate/core';
import { MenuShowComponent } from './menu-show.component';

describe('MenuShowComponent', () => {
	let component: MenuShowComponent;
	let fixture: ComponentFixture<MenuShowComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [MenuShowComponent],
			imports: [HttpClientModule, RouterTestingModule, TranslateModule.forRoot()],
		}).compileComponents();

		fixture = TestBed.createComponent(MenuShowComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
