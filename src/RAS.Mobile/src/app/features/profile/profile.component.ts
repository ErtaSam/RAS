import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup } from '@angular/forms';
import { AccountService } from '../../core/services/account.service';
import { AlertService } from '../../core/services/alert.service';
import { CreditCard, User, UserHelpers } from '../../core/types/user.types';

@Component({
	selector: 'profile',
	templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {
	constructor(private accountService: AccountService, private alertService: AlertService) {
		// Nothing
	}

	public user?: User;
	public form?: UntypedFormGroup;
	public formCard?: UntypedFormGroup;

	public ngOnInit(): void {
		this.accountService.currentUser.subscribe({
			next: (user) => {
				this.user = user ?? undefined;
				this.form = UserHelpers.createForm(user as User);
				const card = localStorage.getItem('ras-mobile-card');
				this.formCard = UserHelpers.createFormCard(card ? (JSON.parse(card) as CreditCard) : undefined);
			},
		});
	}

	public saveCardDetails(): void {
		const card = this.formCard?.value as CreditCard;
		localStorage.setItem('ras-mobile-card', JSON.stringify(card));
		this.alertService.success('Card details saved successfully');
	}
}
