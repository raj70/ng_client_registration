export interface ClientInfo{
    id: string,
    firstName: string,
    lastName:string,
    dob: Date,
    phoneNumber: number,
    emilAddress: string,    
}


export interface Address{
    line1:string,
    line2:string,
    line3:string,
    postcode:string,
    suburb:string,
    country:string
}

export interface ClientCredential{
    userName: string,
    password: string
}

export interface ClientInfoReg{
    id: string,
    firstName: string,
    lastName:string,
    dob: Date,
    phoneNumber: number,
    emilAddress: string,    
    address: Address,
    clientCredential: ClientCredential
}