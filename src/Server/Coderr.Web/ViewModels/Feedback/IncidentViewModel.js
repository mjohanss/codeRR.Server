/// <reference path="../../Scripts/Promise.ts" />
/// <reference path="../../Scripts/CqsClient.ts" />
/// <reference path="../../Scripts/Griffin.Yo.d.ts" />
/// <reference path="../ChartViewModel.ts" />
var OneTrueError;
(function (OneTrueError) {
    var Feedback;
    (function (Feedback) {
        var CqsClient = Griffin.Cqs.CqsClient;
        var GetIncidentFeedback = OneTrueError.Web.Feedback.Queries.GetIncidentFeedback;
        var ApplicationService = OneTrueError.Applications.ApplicationService;
        var IncidentViewModel = (function () {
            function IncidentViewModel() {
            }
            IncidentViewModel.prototype.activate = function (ctx) {
                var _this = this;
                this.ctx = ctx;
                this.updateNavigation();
                this.incidentId = ctx.routeData["incidentId"];
                var query = new GetIncidentFeedback(ctx.routeData["incidentId"]);
                CqsClient.query(query)
                    .done(function (result) {
                    console.log(result);
                    _this.ctx.render(result, IncidentViewModel.directives);
                    ctx.resolve();
                });
            };
            IncidentViewModel.prototype.updateNavigation = function () {
                var _this = this;
                var appId = this.ctx.routeData['applicationId'];
                if (appId != null) {
                    var app = new ApplicationService();
                    app.get(appId)
                        .then(function (result) {
                        var bc = [
                            { href: "/application/" + appId + "/", title: result.Name },
                            { href: "/application/" + appId + "/incident/" + _this.incidentId + "/", title: 'Incident' },
                            { href: "/application/" + appId + "/incident/" + _this.incidentId + "/feedback", title: 'Feedback' }
                        ];
                        OneTrueError.Applications.Navigation.breadcrumbs(bc);
                        OneTrueError.Applications.Navigation.pageTitle = 'Feedback';
                    });
                }
            };
            IncidentViewModel.prototype.deactivate = function () {
            };
            IncidentViewModel.prototype.getTitle = function () {
                return "Incident";
            };
            return IncidentViewModel;
        }());
        IncidentViewModel.directives = {
            Items: {
                Message: {
                    html: function (value) {
                        return nl2br(value);
                    }
                },
                Title: {
                    style: function () {
                        return "color:#ccc";
                    },
                    html: function (value, dto) {
                        return "Written " + moment(dto.WrittenAtUtc).fromNow();
                    }
                },
                EmailAddress: {
                    text: function (value) {
                        return value;
                    },
                    href: function (value) {
                        return "mailto:" + value;
                    },
                    style: function (value) {
                        if (!value) {
                            return "display:none";
                        }
                        return "color: #ee99ee";
                    }
                }
            }
        };
        Feedback.IncidentViewModel = IncidentViewModel;
    })(Feedback = OneTrueError.Feedback || (OneTrueError.Feedback = {}));
})(OneTrueError || (OneTrueError = {}));
//# sourceMappingURL=IncidentViewModel.js.map