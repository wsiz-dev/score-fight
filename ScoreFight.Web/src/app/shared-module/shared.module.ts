import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { SurnameShortcutPipe } from './pipes/surname-shortcut.pipe';
import { ImportantDirective } from './directives/important.directive';
import {AuthProvider} from "./authProvider";

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AuthProvider
  ],
  exports: [HeaderComponent, SurnameShortcutPipe, ImportantDirective],
  declarations: [HeaderComponent, SurnameShortcutPipe, ImportantDirective]
})
export class SharedModule {
}

