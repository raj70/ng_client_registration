
export interface ISubscriberCallback{
    completed(): void;
    next(value: any):void;
    error(error: any): void; 
}