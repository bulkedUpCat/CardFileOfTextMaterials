import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TextMaterialParameters } from 'src/app/models/parameters/TextMaterialParameters';

@Component({
  selector: 'app-sorting-form',
  templateUrl: './sorting-form.component.html',
  styleUrls: ['./sorting-form.component.css']
})
export class SortingFormComponent implements OnInit {
  sortingParamsForm: FormGroup;
  textMaterialParams: TextMaterialParameters;
  searchTitle: string = null;
  searchCategory: string = null;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.sortingParamsForm = this.fb.group({
      searchTitle: [null,[Validators.required]],
      searchCategory: [null,[Validators.required]]
    });
  }

  onSearch(){
    console.log(this.searchTitle + ' ' + this.searchCategory);
  }
}
