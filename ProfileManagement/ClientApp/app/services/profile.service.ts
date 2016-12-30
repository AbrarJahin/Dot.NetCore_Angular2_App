import { Injectable } from '@angular/core';
import { Http, RequestOptions, URLSearchParams, Headers, RequestMethod, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Profile } from '../dataModel/Profile.ts';   //Data Model

@Injectable()

export class ProfileService
{
    //private _productUrl = 'api/products/products.json';
    private _getAllProfileUrl = "http://localhost:63032/api/Profile/Get?currentPageNo=1&pageSize=20";

    constructor(private _http: Http) { }

    getProfiles(): Observable<Profile[]> {
        return this._http.get(this._getAllProfileUrl)
            .map((response: Response) => <Profile[]>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response)
    {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}