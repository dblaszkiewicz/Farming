import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[dynamicPanel]',
})
export class DynamicPanelDirective {
  constructor(public viewContainerRef: ViewContainerRef) {}
}
