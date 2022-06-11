import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';


const materialModules = [
  MatIconModule
]

@NgModule({
  declarations: [],
  exports: [
    ...materialModules,
  ],
  imports: [
    CommonModule,
    ...materialModules
  ]
})
export class MaterialModule { }
