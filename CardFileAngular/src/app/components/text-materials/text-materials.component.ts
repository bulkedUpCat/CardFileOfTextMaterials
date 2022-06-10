import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MaterialCategory } from 'src/app/models/MaterialCategory';
import { TextMaterial } from 'src/app/models/TextMaterial';
import { MaterialCategoryService } from 'src/app/services/material-category.service';
import { TextMaterialService } from 'src/app/services/text-material.service';

@Component({
  selector: 'app-text-materials',
  templateUrl: './text-materials.component.html',
  styleUrls: ['./text-materials.component.css']
})
export class TextMaterialsComponent implements OnInit {
  //category: MaterialCategory;
  //categoryId: number;
  textMaterials: TextMaterial[];

  constructor(private textMaterialService: TextMaterialService,
    private categoryService: MaterialCategoryService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    //this.categoryId = parseInt(this.route.snapshot.paramMap.get('id'));

    //this.getCategoryById(this.categoryId);
    this.getTextMaterials();
  }

  // getCategoryById(id: number){
  //   this.categoryService.getMaterialCategoryById(id).subscribe( mc => {
  //     this.category =  mc;
  //     console.log(this.category);
  //   }, err => {
  //     console.log(err);
  //   });
  // }

  getTextMaterials(){
    return this.textMaterialService.getTextMaterials().subscribe( tm => {
      this.textMaterials = tm;
    });
  }
}
