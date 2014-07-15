﻿namespace Site

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html5
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.Highstock

[<JavaScript>]
module StockControl =

    let Main (el : Dom.Element) =
        JQuery.GetJSON("http://www.highcharts.com/samples/data/jsonp.php?filename=aapl-c.json&callback=?",
            fun (data,_) -> 
                Highcharts.Create(JQuery.Of el,
                    HighstockCfg(
                        Title = TitleCfg(
                            Text = "AAPL stock price"
                        ),
                        RangeSelector = RangeSelectorCfg(
                            Selected = 1.,
                            InputEnabled = ((JQuery.Of el).Width() > 480)
                        ),
                        Series = [|
                            SeriesCfg(
                                Name = "AAPL",
                                Data = As data
                            )
                        |]
                   )
                ) |> ignore
        ) |> ignore
    
    let Sample =
        Samples.Build()
            .Id("Highstock")
            .FileName(__SOURCE_FILE__)
            .Keywords(["highstock";"charts"])
//            .Render(Main)
            .Create()