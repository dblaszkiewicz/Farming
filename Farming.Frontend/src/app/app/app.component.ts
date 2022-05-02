import { Component } from '@angular/core';
import { ApplicationState } from '../state';
import StoreConnectedComponent from '../modules/utilities/store-connected.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent extends StoreConnectedComponent<ApplicationState> {}
