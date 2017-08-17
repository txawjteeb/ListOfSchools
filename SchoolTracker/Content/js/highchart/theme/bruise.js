Highcharts.theme = {
    colors: ['#45ae72', '#CB4E4E','#00aff0', '#058DC7', '#DDDF00', '#24CBE5', '#64E572', 
             '#FF9655', '#FFF263'],
    // chart: {
    //     backgroundColor: {
    //         linearGradient: [0, 0, 500, 500],
    //         stops: [
    //             [0, 'rgb(255, 255, 255)'],
    //             [1, 'rgb(240, 240, 255)']
    //         ]
    //     },
    // },
    title: {
        style: {
            color: '#3a3a44',
            font: '24px "Fjalla One", Verdana, sans-serif'
        }
    },
    subtitle: {
        style: {
            color: '#666666',
            font: 'bold 12px "Source Sans Pro", Verdana, sans-serif'
        }
    },

    legend: {
        itemStyle: {
            font: '10pt Source Sans Pro, Verdana, sans-serif',
            color: 'black'
        },
        itemHoverStyle:{
            color: 'gray'
        }   
    }
};

// Apply the theme
Highcharts.setOptions(Highcharts.theme);