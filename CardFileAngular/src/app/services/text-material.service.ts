import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateTextMaterial } from '../models/CreateTextMaterial';
import { MaterialCategory } from '../models/MaterialCategory';
import { TextMaterial } from '../models/TextMaterial';

@Injectable({
  providedIn: 'root'
})
export class TextMaterialService {

  constructor(private http: HttpClient) { }

  getTextMaterials() : Observable<any>{
    return this.http.get(environment.apiUrl + '/textMaterials');
  }

  getTextMaterialsByCategory(category: MaterialCategory) : Observable<TextMaterial[]>{
    return this.http.get<TextMaterial[]>(`${environment.apiUrl}/textMaterials`,{
      params: {
        id: category.id,
        title: category.title
      }
    });
  }

  getTextMaterialById(id: number) : Observable<TextMaterial>{
    return this.http.get<TextMaterial>(`${environment.apiUrl}/textMaterials/`+ id);
  }

  createTextMaterial(textMaterial: CreateTextMaterial){
    const headers = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json'
      })
    };

    return this.http.post<TextMaterial>(`${environment.apiUrl}/textMaterials`, textMaterial, headers);
  }
}
