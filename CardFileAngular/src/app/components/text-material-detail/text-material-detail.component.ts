import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TextMaterial } from 'src/app/models/TextMaterial';
import { TextMaterialService } from 'src/app/services/text-material.service';

@Component({
  selector: 'app-text-material-detail',
  templateUrl: './text-material-detail.component.html',
  styleUrls: ['./text-material-detail.component.css']
})
export class TextMaterialDetailComponent implements OnInit {
  textMaterial: TextMaterial;

  constructor(private route: ActivatedRoute,
    private textMaterialService: TextMaterialService) { }

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.textMaterialService.getTextMaterialById(id).subscribe( tm => {
      this.textMaterial = tm;
    })
  }

}
