Pod::Spec.new do |s|
  s.name         = 'TagDataTranslation'
  s.version      = '3.0.0'
  s.summary      = 'GS1 EPC Tag Data Translation for iOS'
  s.description  = <<-DESC
    Encode and decode all EPC schemes (SGTIN, SSCC, SGLN, GRAI, GIAI, GSRN, GDTI, and more)
    on iOS. Supports TDS 2.3 with Digital Link URIs and hostname encoding.
    Compiled from .NET via NativeAOT -- zero runtime dependencies.
  DESC
  s.homepage     = 'https://github.com/dannyhaak/TagDataTranslation'
  s.license      = { :type => 'BSL-1.1', :file => 'LICENSE.md' }
  s.author       = { 'Danny Haak' => 'tdt@mimasu.nl' }
  s.source       = { :http => "https://github.com/dannyhaak/TagDataTranslation/releases/download/v#{s.version}/TagDataTranslation.xcframework.zip" }
  s.ios.deployment_target = '15.0'
  s.vendored_frameworks = 'TagDataTranslation.xcframework'
  s.swift_versions = ['5.9', '5.10', '6.0']
end
