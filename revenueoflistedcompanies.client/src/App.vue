<script>
    import DemoGrid from './Grid.vue'

    export default {
        components: {
            DemoGrid
        },
        data: () => ({
            searchQuery: "",
            gridColumns: ['出表日期', '資料年月', '公司代號', '公司名稱', '產業別', '營業收入-當月營收', '營業收入-上月營收', '營業收入-去年當月營收', '營業收入-上月比較增減(%)', '營業收入-去年同月增減(%)', '累計營業收入-當月累計營收', '累計營業收入-去年累計營收', '累計營業收入-前期比較增減(%)', '備註'],
            gridData: []
        }),
        mounted: function () {
            this.searchData();
        },
        methods: {
            searchData() {
                var url = `https://localhost:7289/api/GetCompaniesData?code=` + this.searchQuery;
                var self = this;
                this.fetchGET(url).then((resp) => {
                    self.gridData = resp.map(item => {
                        return {
                            '出表日期': item.reporT_DATE,                          // 將 REPORT_DATE 轉換為 '出表日期'
                            '資料年月': item.datA_YEARMONTH,                        // 將 DATA_YEARMONTH 轉換為 '資料年月'
                            '公司代號': item.companY_CODE,                          // 將 COMPANY_CODE 轉換為 '公司代號'
                            '公司名稱': item.companY_NAME,                          // 將 COMPANY_NAME 轉換為 '公司名稱'
                            '產業別': item.industry,                               // 將 INDUSTRY 轉換為 '產業別'
                            '營業收入-當月營收': item.revenuE_CURRENT,              // 將 REVENUE_CURRENT 轉換為 '營業收入-當月營收'
                            '營業收入-上月營收': item.revenuE_PREV_MONTH,           // 將 REVENUE_PREV_MONTH 轉換為 '營業收入-上月營收'
                            '營業收入-去年當月營收': item.revenuE_LAST_YEAR,         // 將 REVENUE_LAST_YEAR 轉換為 '營業收入-去年當月營收'
                            '營業收入-上月比較增減(%)': item.monthlY_CHANGE,       // 將 MONTHLY_CHANGE 轉換為 '營業收入-上月比較增減(%)'
                            '營業收入-去年同月增減(%)': item.yoY_CHANGE,          // 將 YOY_CHANGE 轉換為 '營業收入-去年同月增減(%)'
                            '累計營業收入-當月累計營收': item.cumulativE_REVENUE,  // 將 CUMULATIVE_REVENUE 轉換為 '累計營業收入-當月累計營收'
                            '累計營業收入-去年累計營收': item.cumulativE_LAST_YEAR, // 將 CUMULATIVE_LAST_YEAR 轉換為 '累計營業收入-去年累計營收'
                            '累計營業收入-前期比較增減(%)': item.cumulativE_CHANGE, // 將 CUMULATIVE_CHANGE 轉換為 '累計營業收入-前期比較增減(%)'
                            '備註': item.remarks                                  // 將 REMARKS 轉換為 '備註'
                        };
                    });

                })
            },
            updatedata() {
                var url = `https://localhost:7289/api/GetCompaniesData`;
                this.fetchPUT(url);
            },
            fetchGET(url) {
                var self = this;
                var promise = new Promise((resolve, reject) => {
                    fetch(url, {
                        method: 'GET',
                        headers: {
                            'Content-Type': 'application/json',
                        }
                    })
                        .then((x) => {
                            x.text().then(respText => {
                                self.aaa = respText;
                                if (x.ok) {
                                    resolve(JSON.parse(respText))
                                }
                                else {
                                    resolve(respText)
                                }
                            })
                        })
                })
                promise.then(x => x).catch(error => {
                    console.error({ 'Error': error })
                })
                return promise
            },
            fetchPUT(url) {
                var self = this;
                var promise = new Promise((resolve, reject) => {
                    fetch(url, {
                        method: 'PUT',
                    })
                })
                promise.then(x => x).catch(error => {
                    console.error({ 'Error': error })
                })
                return promise
            },
        }
    }
</script>

<template>
    公司代號：
    <input name="query" v-model="searchQuery">
    <input type="button" value="搜尋" @click="searchData" />
    <input type="button" value="更新資料" @click="updatedata" />
    <DemoGrid :data="gridData"
              :columns="gridColumns">
    </DemoGrid>
</template>