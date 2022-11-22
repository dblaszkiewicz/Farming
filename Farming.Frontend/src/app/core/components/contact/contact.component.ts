import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { SnackbarService } from '../../services/snackbar.service';
import { UserService } from '../../services/user.service';
import { SpinnerStore } from '../../stores/spinner.store';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {

  constructor(private userService: UserService, private snackbarService: SnackbarService, private spinnerStore: SpinnerStore) { }

  ngOnInit(): void {
  }

  public async seed() {
    this.spinnerStore.startSpinner();
    const res = await lastValueFrom(this.userService.seedSampleData());
    this.spinnerStore.stopSpinner();

    if (res) {
      this.snackbarService.showSuccess("Pomyślnie zaseedowano dane");
    } else {
      this.snackbarService.showFail("Dane były już zaseedowane")
    }
  }
}
