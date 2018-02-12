// SJVAPCD 
// www.valleyair.org
// RAAN App chart config
// Author: Anton Simanov

// Static data for testing
// 
var ozoneData = [37,33,28,24,20,18,16,15,19,30,43,58,68,73,67,65,69,69,71,69,63,63,54,52,50]
var pmData = [14,8,7,9,9,6,9,8,11,12,11,10,12,16,9,7,16,13,15,16,13,24,15,14,18]

// Chart Config
// 

    // Ozone Chart
    $(function () {
        $('#chart1').highcharts({
            chart: {
                type: 'spline',
                backgroundColor: null
            },

            title: {
                text: '<strong>' + 'OZONE' + '</strong>',
                style: {
                        color: '#1c61ad',
                        fontFamily: "Lato",
                    }
            },

            xAxis: {
                title: {
                    text: 'Hour',
                    
                    style: {
                        color: '#525151',
                        font: '14px Lato',
                        fontWeight: 'bold'
                    },
                },
                categories: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
                tickInterval: 2,
            },

            yAxis: [{
                // Left yAxis
                title: {
                    text: 'Hourly Ozone Concentration (ppb)',
                    style: {
                        color: '#525151',
                        font: '14px Lato',
                        fontWeight: 'bold'
                    },
                },

                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }],

                labels: {
                    style: {
                        color: '#525151',
                        font: '12px Lato',
                        fontWeight: 'bold'
                    },
                    formatter: function () {
                        return this.value;
                    }
                },

                min: 0,
                max: 150,
                endOnTick: false,
                tickPositions: [0, 60, 76, 96, 115, 150],

            }, {
                // Right yAxis
                title: {
                    text: ''
                },

                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }],

                min: 0,
                max: 150,
                endOnTick: false,
                tickPositions: [0, 60, 76, 96, 115, 150],

                labels: {
                    formatter: function() {
                        return {
                                '0': '<span class="scale-1"></span>',
                                '60': '<span class="scale-2"></span>',
                                '76': '<span class="scale-3"></span>',
                                '96': '<span class="scale-4"></span>',
                                '115': '<span class="scale-5"></span>',
                            }[this.value];
                    },        

                    useHTML: true,
                },

                opposite: true

            }],

            tooltip: {
                useHTML: true,
                borderWidth: 2,
                valueSuffix: 'ppb'
            },

            legend: {
                enabled: false
            },

            credits: {
                enabled: false
            },

            colors: ['#06e300', '#fef924', '#fa8005', '#fd1700', '#9d034b', 
                        '#710020'],

            colorAxis: {
                dataClassColor: 'category',
                    dataClasses: [{
                        to: 50
                    }, {
                        from: 51,
                        to: 100
                    }, {
                        from: 101,
                        to: 150
                    }, {
                        from: 151,
                        to: 200
                    }, {
                        from: 201,
                        to: 300
                    },  {
                        from: 301
                    }],
            },     

            series: [{
                name: 'Ozone',
                lineWidth: 3,
                color: '#333333',
                dashStyle: 'shortdash',
                // Static data to be replaced with dynamic data for production
                data: ozoneData,
                marker: {
                    enabled: true,
                    symbol: 'circle',
                    radius: 4
                },
                
                states: {
                    hover: {
                        color: Highcharts.Color
                    }
                },
            }]

        });
    });

    // PM Chart
    $(function () {
        $('#chart2').highcharts({
            chart: {
                type: 'spline'
            },

            title: {
                text: '<strong>' + 'PM 2.5' + '</strong>',
                style: {
                        color: '#1c61ad',
                        fontFamily: "Lato",
                    }
            },

            xAxis: {
                title: {
                    text: 'Hour',
                    
                    style: {
                        color: '#525151',
                        font: '14px Lato',
                        fontWeight: 'bold'
                    },
                },
                categories: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
                tickInterval: 2
            },

            yAxis: [{
                // Left yAxis
                title: {
                    text: 'Hourly PM 2.5 Concentration (µg/m³)',

                    style: {
                        color: '#525151',
                        font: '14px Lato',
                        fontWeight: 'bold'
                    },
                },

                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }],

                labels: {
                    style: {
                        color: '#525151',
                        font: '12px Lato',
                        fontWeight: 'bold'
                    },
                    formatter: function () {
                        return this.value;
                    }
                },

                min: 0,
                max: 95,
                endOnTick: false,
                tickPositions: [0, 13, 36, 56, 75, 95],

            }, {
                // Right yAxis
                title: {
                    text: ''
                },

                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }],

                min: 0,
                max: 95,
                endOnTick: false,
                tickPositions: [0, 13, 36, 56, 75, 95],

                labels: {
                    formatter: function() {
                        return {
                                '0': '<span class="scale-1"></span>',
                                '13': '<span class="scale-2"></span>',
                                '36': '<span class="scale-3"></span>',
                                '56': '<span class="scale-4"></span>',
                                '75': '<span class="scale-5"></span>',
                            }[this.value];

                    },        

                    useHTML: true,
                },

                opposite: true
            }],

            tooltip: {
                valueSuffix: 'µg/m³'
            },

            legend: {
                enabled: false
            },

            credits: {
                enabled: false
            },
            
            series: [{
                name: 'PM 2.5',
                lineWidth: 3,
                color: '#333333',
                dashStyle: 'shortdash',
                // Static data to be replaced with dynamic data for production
                data: pmData,
                marker: {
                    enabled: true,
                    symbol: 'circle',
                    radius: 4
                }
            }]
        });
    });

