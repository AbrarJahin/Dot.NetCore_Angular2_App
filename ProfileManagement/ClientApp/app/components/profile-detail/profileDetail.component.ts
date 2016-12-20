import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';

@Component({
    selector: 'profile-detail',
    template: require('./profileDetail.component.html')
})
export class ProfileDetailComponent
{
    private _getProfileBaseUrl: string = "http://localhost:63032/api/Profile/Get/";
    private id: number;
    private data: any;

    constructor(private _route: ActivatedRoute, private _http: Http)
    {
        this._route.params.subscribe(params => {
            this.id = parseInt(params['id']); // (+) converts string 'id' to a number
        });

        this._http.get(this._getProfileBaseUrl + this.id)
            .subscribe(result => {
                this.data = result.text();
                console.log(this.data);
            });
    }
}
