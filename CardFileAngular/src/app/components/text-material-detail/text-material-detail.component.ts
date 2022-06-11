import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TextMaterial } from 'src/app/models/TextMaterial';
import { AuthService } from 'src/app/services/auth.service';
import { TextMaterialService } from 'src/app/services/text-material.service';

@Component({
  selector: 'app-text-material-detail',
  templateUrl: './text-material-detail.component.html',
  styleUrls: ['./text-material-detail.component.css']
})
export class TextMaterialDetailComponent implements OnInit {
  textMaterial: TextMaterial;
  isManager: boolean = false;
  loadedStatus: boolean = false;

  constructor(private route: ActivatedRoute,
    private textMaterialService: TextMaterialService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.textMaterialService.getTextMaterialById(id).subscribe( tm => {
      this.loadedStatus = true;
      this.textMaterial = tm;
    });

    this.authService.claims.subscribe(c => {
      if (c){
        this.isManager = c.includes('Manager');
      }
    });
  }

  approveTextMaterial(){
    this.textMaterial.approvalStatusId = 1;
    this.textMaterialService.updateTextMaterial(this.textMaterial).subscribe(x => {
      this.textMaterialService.getTextMaterialById(this.textMaterial.id).subscribe(tm => {
        this.textMaterial = tm;
        this.router.navigateByUrl('/main');
      });
    });
  }

  rejectTextMaterial(){
    this.textMaterial.approvalStatusId = 2;
    this.textMaterialService.updateTextMaterial(this.textMaterial).subscribe(x => {
      this.textMaterialService.getTextMaterialById(this.textMaterial.id).subscribe(tm => {
        this.textMaterial = tm;
        this.router.navigateByUrl('/main');
      })
    })
  }
}
