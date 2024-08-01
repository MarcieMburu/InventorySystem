import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { InventoryDetail } from './inventory-detail.model';
import { NgForm } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class InventoryDetailService {

  url: string = environment.apiBaseUrl + '/InventoryDetail'
  list: InventoryDetail[] = [];
  formData: InventoryDetail = new InventoryDetail()
  formSubmitted: boolean = false;
  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as InventoryDetail[]
        },
        error: err => { console.log(err) }
      })
  }

  postInventoryDetail() {
    return this.http.post(this.url, this.formData)
  }

  putInventoryDetail() {
    return this.http.put(this.url + '/' + this.formData.itemID, this.formData)
  }


  deleteInventoryDetail(id: number) {
    return this.http.delete(this.url + '/' + id)
  }


  resetForm(form: NgForm) {
    form.form.reset()
    this.formData = new InventoryDetail()
    this.formSubmitted = false
  }
}
