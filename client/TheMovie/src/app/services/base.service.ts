import { HttpClient, HttpHeaders } from "@angular/common/http";

import { from, Observable } from 'rxjs'; 
import { map, catchError } from 'rxjs/operators';

export abstract class BaseService {
    //protected UrlService: string = "https://localhost:44347/";
    protected UrlService: string = "https://themovieservice20210901091818.azurewebsites.net/";
    
    protected GetHeaderJson(){
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
    }

    protected extractData(response: any){
        return response || {};
    }

    protected serviceError(error: Response | any){
        let errMsg: string;

        if (error instanceof Response) {
            errMsg = `${error.status} - ${error.statusText || ''}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(error);
        return Observable.throw(error);
    }
}  