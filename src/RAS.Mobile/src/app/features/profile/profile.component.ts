import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup } from '@angular/forms';
import { AccountService } from '../../core/services/account.service';
import { User, UserHelpers } from '../../core/types/user.types';

@Component({
	selector: 'profile',
	templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {
	constructor(private accountService: AccountService) {
		// Nothing
	}

	public user?: User;
	public form?: UntypedFormGroup;

	public ngOnInit(): void {
		this.accountService.currentUser.subscribe({
			next: (user) => {
				this.user = user ?? undefined;
				this.form = UserHelpers.createForm(user as User);
			},
		});
	}
}
