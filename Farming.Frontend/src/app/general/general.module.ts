import { NgModule } from '@angular/core';

import { GeneralRoutingModule } from './general-routing.module';
import { ContactComponent } from './contact/contact.component';
import { SharedModule } from '../shared/shared.module';
import { NavigationComponent } from './navigation/navigation.component';

@NgModule({
  declarations: [ContactComponent, NavigationComponent],
  imports: [GeneralRoutingModule, SharedModule],
})
export class GeneralModule {}
