using System;
using System.Collections;
using System.Collections.Generic;

namespace SicemOperation.Models;

public class IncidentGridModel<T>{
    public int TotalDays {get;set;}
    public DateTime From {get;set;}
    public DateTime To {get;set;}
    public IEnumerable<IncidentGridElementModel<T>> Elements {get;set;} = default!;
}

public class IncidentGridElementModel<T> {
    public string Group {get;set;} = default!;
    public string IncidentName {get;set;} = default!;
    public IEnumerable<T> Data {get;set;} = default!;

}