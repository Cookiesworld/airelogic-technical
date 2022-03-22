import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BugService {

  constructor(private http: HttpClient) {  
   }

   public getBugs() {
     return this.http.get("https://localhost:44330/api/bugs"); 
   }
}
